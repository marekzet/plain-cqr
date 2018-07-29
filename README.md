# Plain CQRS
Plain CQRS is a library that supports implementing CQRS pattern using most popular frameworks, by providing dispatchers implementations out of the box.

# Get Started
Install library via
**Package Manager** ```Install-Package PlainCQRS.Core -Version 1.0.0``` or
**.Net CLI** ```dotnet add package PlainCQRS.Core --version 1.0.0```

### Commands

Create sample command and command handler

```cs
public class DoNothing : ICommand
{
}
```
```cs
public class DoNothingHandler : ICommandHandler<DoNothing>
{
    public void Handle(DoNothing command)
    {
    }
}
```
Register command and command handler in the container
```cs
public void ConfigureContainer(ContainerBuilder builder)
{
    builder.RegisterType<DoNothingHandler>()
      .As<ICommandHandler<DoNothing>>()
      .InstancePerLifetimeScope();
}
```
Use
```cs
public class HomeController : Controller
{
    private readonly ICommandSender commandBus;

    public HomeController(ICommandSender commandBus)
    {
        this.commandBus = commandBus;
    }

    public IActionResult DoSomething()
    {
        commandBus.Send(new DoNothing());
        return RedirectToAction(nameof(Index));
    }
    //... other actions
}
```

### Queries

Create sample query and query handler

```cs
public class GetSomething : IQuery<SomethingViewModel>
{
}
```
```cs
public class GetSomethingHandler : IQueryHandler<GetSomething, SomethingViewModel>
{
    public SomethingViewModel Handle(GetSomething query)
    {
        return new SomethingViewModel
        {
            Thing = "I am the thing"
        };
    }
}
```
Register query and query handler in the container
```cs
public void ConfigureContainer(ContainerBuilder builder)
{
    builder.RegisterType<GetSomethingHandler>()
      .As<IQueryHandler<GetSomething, SomethingViewModel>>()
      .InstancePerLifetimeScope();
}
```
Use
```cs
public class HomeController : Controller
{
    private readonly IQueryDispatcher queryDispatcher;

    public HomeController(IQueryDispatcher queryDispatcher)
    {
        this.queryDispatcher = queryDispatcher;
    }

    public IActionResult GetSomething()
    {
        var viewModel = queryDispatcher.Execute(new GetSomething());
        return View(viewModel);
    }
}
```

### Events

Create event and event handler

```cs
public class SomethingHappened : IEvent
{
    public Guid Id => Guid.NewGuid();
    // other attributes
}
```
```cs
public class SomethingHappenedHandler : IEventHandler<SomethingHappened>
{
    public void Handle(SomethingHappened @event)
    {
    }
}
```

Register event and event handler

```cs
public void ConfigureContainer(ContainerBuilder builder)
{
    builder.RegisterType<SomethingHappenedHandler>()
      .As<IEventHandler<SomethingHappened>>()
      .InstancePerLifetimeScope();
}
```
It is also possible to register more than one handler for particular event
```cs
public void ConfigureContainer(ContainerBuilder builder)
{
    builder.RegisterType<NothingHappenedHandlerOne>()
        .As<IEventHandler<NotingHappened>>()
        .InstancePerLifetimeScope();

    builder.RegisterType<NothingHappenedHandlerTwo>()
        .As<IEventHandler<NotingHappened>>()
        .InstancePerLifetimeScope();
}
```
Publish event. In this example event is published after handling a DoNothing command from DoNothing handler
```cs
public class DoNothingHandler : ICommandHandler<DoNothing>
{
    private readonly IEventPublisher eventPublisher;

    public DoNothingHandler(IEventPublisher eventPublisher)
    {
        this.eventPublisher = eventPublisher;
    }
    
    public void Handle(DoNothing command)
    {
        // .. handle command
        
        // publish event
        eventPublisher.Publish(new NotingHappened());
    }
}
```

## Async
Each handler and dispatcher has its async equivalent listed below.
* `PlainCQRS.Core.Commands.ICommandHandlerAsync<in TCommand> where TCommand : ICommand`
* `PlainCQRS.Core.Commands.ICommandSenderAsync`
* `PlainCQRS.Core.Queries.IQueryHandlerAsync<in TQuery, TResult> where TQuery : IQuery<TResult>`
* `PlainCQRS.Core.Queries.IQueryDispatcherAsync`
* `PlainCQRS.Core.Events.IEventHandlerAsync<in TEvent> where TEvent : IEvent`
* `PlainCQRS.Core.Events.IEventPublisherAsync`

Usage is similar to the synchronous implementations.
```cs
public class GetSomethingAsyncHandler : IQueryHandlerAsync<GetSomethingAsync, SomethingViewModel>
{
    public async Task<SomethingViewModel> HandleAsync(GetSomethingAsync query, 
        CancellationToken cancellationToken = default(CancellationToken))
    {
        // await long running task
    }
}
```
```cs
public void ConfigureContainer(ContainerBuilder builder)
{
    // other registrations
    
    builder.RegisterType<GetSomethingAsyncHandler>()
        .As<IQueryHandlerAsync<GetSomethingAsync, SomethingViewModel>>()
        .InstancePerLifetimeScope();
}
```
```cs
public class HomeController : Controller
{
    private readonly IQueryDispatcherAsync queryDispatcher;

    public HomeController(IQueryDispatcherAsync queryDispatcher)
    {
        this.queryDispatcher = queryDispatcher;
    }

    public async Task<IActionResult> GetSomething()
    {
        var viewModel = await queryDispatcher.ExecuteAsync(new GetSomethingAsync());
        return View(viewModel);
    }
}
```
## Autofac with Asp Net Core
To get started with Plain CQRS in Asp Net Core app using Autofac container simply register `PlainCQRS.Autofac.AspNetCoreModule` in 
your Autofac container.

```cs
public void ConfigureContainer(ContainerBuilder builder)
{
    builder.RegisterModule(new AspNetCoreModule());
}
```
This will register default implementations of objects dispatchers. Now you can start registering yours commands/queries/events 

```cs
public void ConfigureContainer(ContainerBuilder builder)
{
    builder.RegisterModule(new AspNetCoreModule());

    builder.RegisterType<DoNothingHandler>()
      .As<ICommandHandler<DoNothing>>()
      .InstancePerLifetimeScope();

    builder.RegisterType<GetSomethingHandler>()
      .As<IQueryHandler<GetSomething, SomethingViewModel>>()
      .InstancePerLifetimeScope();

    builder.RegisterType<NothingHappenedHandler>()
        .As<IEventHandler<NotingHappened>>()
        .InstancePerLifetimeScope();
}
```
## Plain CQRS with other frameworks
I am going to successively add implementations for other frameworks, however it is possible to write own implementation or overwrite
default ones. All you need to to is to implement following interfaces and register implementations in your container. 
* `PlainCQRS.Core.Commands.ICommandSender`
* `PlainCQRS.Core.Commands.ICommandSenderAsync`
* `PlainCQRS.Core.Commands.ICommandHandler<in TCommand> where TCommand : ICommand`
* `PlainCQRS.Core.Commands.ICommandHandlerAsync<in TCommand> where TCommand : ICommand`
* `PlainCQRS.Core.Events.IEventPublisher`
* `PlainCQRS.Core.Events.IEventPublisherAsync`
* `PlainCQRS.Core.Events.IEventHandler<TEvent> where TEvent : IEvent`
* `PlainCQRS.Core.Events.IEventHandlerAsync<in TEvent> where TEvent : IEvent`
* `PlainCQRS.Core.Queries.IQueryDispatcher`
* `PlainCQRS.Core.Queries.IQueryDispatcherAsync`
* `PlainCQRS.Core.Queries.IQueryHandler<TQuery, TResult> where TQuery : IQuery<TResult>`
* `PlainCQRS.Core.Queries.IQueryHandlerAsync<in TQuery, TResult> where TQuery : IQuery<TResult>`
