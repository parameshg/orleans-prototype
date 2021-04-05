## Orleans Prototype

This repository contains projects describing a simple prototype of how Microsoft Orleans can be used to develop a distributed and scalable server capable of receiving events from various types of IoT devices, processing them and sending back processed output to devices or to another system.

| Project                | Type               | Description                                                                                             |
| :--------------------- | :----------------- | :-------------------------------------------------------------------------------------------------------|
| IoT.Server             | .NET Standard 2.0  | Contains core business logic of how server reacts when receiving events from devices                    |
| IoT.Server.Interfaces  | .NET Standard 2.0  | Contains interfaces of core bussines logic that is used by Orleans client to communicate with server    |
| IoT.Server.Host        | .NET Framework 4.8 | Contains Windows Forms classes that hosts server on Orleans runtime and provides lifecycle management   |
| IoT.Devices            | .NET Framework 4.8 | Contains Windows Forms classes that emulates IoT devices communication to server api endpoint           |
| IoT.Api                | .NET 5.0           | Contains API classes that acts as REST endpoint to devices and an Orleans client to server              |
| IoT.Shared             | .NET Standard 2.0  | Contains entity and enumeration classes shared between API and devices                                  |

### Introduction

Orleans is a cross-platform framework from Microsoft for building robust, scalable distributed applications using .NET technology stack. Orleans can scale from a single on-premises server to globally distributed, highly-available applications in the cloud. Orleans takes familiar concepts like objects, interfaces, async/await, and try/catch and extends them to multi-server environments. This helps developers experienced with single-server applications transition to building resilient, scalable cloud services and other distributed applications. For this reason, Orleans has often been referred to as "Distributed .NET".

It was created by Microsoft Research and introduced the [Virtual Actor Model](https://www.microsoft.com/en-us/research/wp-content/uploads/2016/02/Orleans-MSR-TR-2014-41.pdf) as a novel approach to building a new generation of distributed systems for the Cloud era. The core of Orleans is its programming model which tames the complexity inherent to highly-parallel distributed systems without restricting capabilities or imposing onerous constraints on the developer.

The fundamental building block in any Orleans application is a grain. Grains are entities comprising user-defined identity, behavior, and state. Grain identities are user-defined keys which make Grains always available for invocation. Grains can be invoked by other grains or by external clients such as Web frontends, via strongly-typed communication interfaces (contracts). Each grain is an instance of a class which implements one or more of these interfaces.

![Grain Composition](/images/grain-composition.svg)

Grains can have volatile and/or persistent state that can be stored in any storage system. As such, grains implicitly partition application state, enabling automatic scalability and simplifying recovery from failures. Grain state is kept in memory while the grain is active, leading to lower latency and less load on data stores.

![Grain Lifecycle](/images/grain-lifecycle.svg)

Instantiation of grains is automatically performed on demand by the Orleans runtime. Grains which are not used for a while are automatically removed from memory to free up resources. This is possible because of their stable identity, which allows invoking grains whether they are already loaded into memory or not. This also allows for transparent recovery from failure because the caller does not need to know on which server a grain is instantiated on at any point in time. Grains have a managed lifecycle, with the Orleans runtime responsible for activating/deactivating, and placing/locating grains as needed. This allows the developer to write code as if all grains were always in-memory. Taken together, the stable identity, statefulness, and managed lifecycle of Grains are core factors that make systems built on Orleans scalable, performant, & reliable without forcing developers to write complex distributed systems code.

### Architecture

The following diagram shows the context in which the projects are arranged. It starts with IoT devices modelled as WinForms (IoT.Devices) using .NET Framework 4.8 which can generate events modelled as random numbers to process them depending on its device type modelled as a predefined function. Currently, following device types are supported:
* Prime
* Factorial
* Mean
* Variance
* Standard Deviation

![Context Diagram](/images/prototype-context-diagram.png)

The events are received by a stateless scalable API endpoint (IoT.Api) which acts as a client to Orleans host and forwards the call to the devide type specific grain. The grain is activated by Orleans runtiem if its not already present in the host memory, processes the event and respons with the result after persisting the current state to a database. This prototype uses SQL Server database for grain persistence, clustering and reminders. While the database itself is not included, SQL scripts to create necessary tables are included. When the API receives the response from the grain, it forwards back to its requesting device which displays them in its user-interface.

### User Interfaces

The following section shows the Graphical User Interfaces for Orleans server host and device client modelled as WinForms using .NET Framework 4.8. Since the server host is modelled as a single process, the user-interface faclitates to run multiple server processes on different port numbers in a single system listening at the local interface (localhost or 127.0.0.1). The server also connects to the local backend SQL server to register itself to the cluster.

![Server Host](/images/server-host.png)

The device client user-interface faciliates generation of random numbers in a regular intervels of time between specified minimum and maximun values. The user-interface also allows to configure the device type as one of the supported function.

![Client Device](/images/client-device.png)

### State Storage

The prototype uses Microsoft SQL Server for persisting grain state, managing the cluster with multiple server nodes modelled as a process to be deployed on a single system, and persisting long-term reminders.

![Server Storage](/images/server-storage.png)

Though the entire database is not provided with this prototype, the following SQL scripts to create necessary tables are included.

* SQLServer-Main.sql
* SQLServer-Persistence.sql
* SQLServer-Clustering.sql
* SQLServer-Reminders.sql

### Execution Considerations

In order to start the prototype, follow the below order to satisfiy the dependencies of components.

1. Prepare the SQL server database with the provided scripts
2. Update appsettings.json for IoT.Api project with the database connection string
3. Start one or more IoT.Server.Host.exe on differet ports
4. Start IoT.Api.exe, by default on port 5000
5. Update IoT.Devices.exe.config for IoT.Devices project with the database connection string
6. Start one or more IoT.Devices.exe with different configurations