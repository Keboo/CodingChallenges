# Sharpening your testing skill
This small ASP.NET Core application implements a hosted service that delays the shutting down of the application.
It is based on the example given by Andrew Lock in his blog [here](https://andrewlock.net/deploying-asp-net-core-applications-to-kubernetes-part-11-avoiding-downtime-in-rolling-deployments-by-blocking-sigterm/)

## Challenge
The project contains a hosted service called `ApplicationLifecycleService`. 
This class contain a method called `StartAsync`. 
The challenge is to simply write any needed test(s) for this method. 
You are allowed to refactor the code in anyway you see fit as long and the behavior remains the same.
You are allowed to use any testing tools or techniques that you feel are appropriate.
