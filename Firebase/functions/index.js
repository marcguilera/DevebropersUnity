var functions = require('firebase-functions');

exports.acceptFriendRequest = functions.database.ref('/friendship/requests/{userId}/{requestId}/Status')
    .onUpdate(event => {
        var data = event.data;

        // Exit if it was deleted
        if (!data.exists()) {
            return 0;
        }

        var status = data.val();
        if (status !== "Accepted") {
            return 0;
        }
        
        var statusRef = data.ref;
        var requestRef = statusRef.parent;
        var friendshipsRef = requestRef.parent.parent.child('frienships');
        var request = requestRef.val();

        var deleteRequest = requestRef.remove();
        var selfFrienship = friendshipsRef.child(request.SourceUserId).push({ UserId: request.TargetUserId, Name: request.TargetUserName});
        var otherFrienship = friendshipsRef.child(request.TargetUserId).push({ UserId: request.SourceUserId, Name: request.SourceUserName});
        
        return Promise.all([selfFrienship, otherFrienship, deleteRequest]);
});

exports.deleteFriendship = functions.database.ref('/friendship/friendship/{userId}/{friendshipId}')
    .onDelete(event => {
        var eventSnapshot = event.data;

        var data = eventSnapshot.val();

        return friendshipsRef.child(data.UserId).equalTo('UserId', event.params.userId).remove();
});