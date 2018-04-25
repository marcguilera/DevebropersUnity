# DevebropersUnity

The goal of this library is to provide a set of classes and utilities for Unity in C#.  The majority of components can be used outside of Unity because they don't include any dependency on the engine. 

## Usage

This library is divided into logical C# solutions. You can import one, many or all in your project independently. I suggest using NuGet. 

## Domain Driven Design

I have used the [DDD pattern](https://en.wikipedia.org/wiki/Domain-driven_design) to provide a layer of abstraction over the different packages of this library. 

Each solution has its own DomainFactory which is in charge of creating everything needed by that solution. To use a package you will need to create its DomainFactory.

**Example:**

```
var domain = new RandomDomainFactories();
var nextInt = domain.random.Get();
```

Some domains require objects to be injected from other domains. 

Feel free to extend DomainFactories with your own functionality as well as injecting your own implementation of a given interface instead of the one provided.


## Packages

* **Authentication:** Provides functionality to authenticate users anonymously, by email, with facebook, google or GitHub.  
* **Common:** Contains a set of utilities required by other packages such as string treatment, reactive programming, and exception handling.
* **Data:** Exposes functionality to persist data as well as entity utilities. 
* **Diagnostics:** Initializes an event sender which can be used for analytics and error reporting.
* **Domains:** Superclasses to support the domain pattern.
* **Firebase:** Firebase specific implementations for data persistence, diagnostics, invitations, etc. 
* **Friendship:** Provides users with the option to befriend other users.
* **I18n:** Domain to localize strings and other values.
* **Invites:** Exposes the functionality to send invites to the game. 
* **Location:** Provides access to the GPS information.
* **Masking:** String masking for a number of things such as Email.
* **Messaging:** Allows the application to subscribe itself to notifications and to send messages.
* **Nonce:** [Nonce](https://en.wikipedia.org/wiki/Cryptographic_nonce) generation and redemption.
* **Random:** Wraps the C# functionalities and adds some sugar to it.
* **Settings:** Remote configuration capabilities with auto update.
* **Storage:** Local and remote storage utilities.
* **Users:** Everything related to users.

## Interfaces
All objects provided by DomainFactories are exposed through virtual interfaces should make mocking and testing very easy. 

## WIP
This is a work in progress and I am planning to add more functionality as I need it in my projects but pull requests are welcome. 