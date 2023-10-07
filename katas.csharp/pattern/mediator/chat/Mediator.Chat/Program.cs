using Mediator.Chat;

Mediator.Chat.Mediator mediator = new();

ICollage Pepe = new User(mediator);
ICollage Admin = new UserAdmin(mediator);
ICollage Admin2 = new UserAdmin(mediator);

mediator.Add(Pepe);
mediator.Add(Admin);
mediator.Add(Admin2);

Pepe.Communicate("Hello, Admin!. I have a problem.");
Admin.Communicate("Hello, Pepe!. What is your problem?");
Admin2.Communicate("Hello, Pepe!. I am the second admin.");
Pepe.Communicate("My router is not working.");
Admin.Communicate("I will check it.");
Admin.Communicate("I will restart it.");
Pepe.Communicate("Thank you.");


