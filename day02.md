# .NET Geekwise Day 2
---
Recommended Resource: http://www.learncs.org/
### Homework Review
- Create a new url endpoint (method) in the HomeController
- Create an associated view that will load when you navigate to the new endpoint
- Add a link to your new view in the header bar
- Experiment with the *register* and *login* functionality by creating an account on your site
- **Bonus:** Make your new page only load when you are logged in. Hint: look at the *manage* pages



---
# Building an MVC Application

> Create a new project called `MvcMovie` which we will use for the following guide. Make sure you choose *Individual User Accounts* as the Authentication type for this project. We will eventually be following a comprehensive example from Microsoft, so this will allow us to merge seemlessly into thier code.

### Adding a Controller

MVC invokes controller classes (and the action methods within them) depending on the incoming URL. The default URL routing logic used by MVC uses the following format:
```
/[Controller]/[Action]/[Parameters]
```
The first segment determines the controller to run. For example, a url such as `localhost:5000/HelloWorld` would map to `HelloWorldController`. The next section will determine which *Action* (or method) to run. To view the `Index` within `HelloWorldController` we would use the URL `localhost:5000/HelloWorld/Index`.

You set the format for routing in the *Startup.cs* file:
```c
app.UseMvc(routes =>
{
    routes.MapRoute(
        name: "default",
        template: "{controller=Home}/{action=Index}/{id?}");
});
```
Here we can see there are defaults applied to the controller and action. So if you don't supply a controller in the URL, it will default to *Home*. Similarly, the action will default to *Index*. This means that if we navigated to `localhost:5000/HelloWorld/` it would run the `Index` action since this is the default when no action is provided.

Let's experiement with this. Add a new controller to your project and name it `HelloWorldController`. You can add a controller by right-clicking on the *Controllers* folder and selecting `Add > New Item`. Copy the code below into your controller:

HelloWorldController.cs
```c
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace MyProject.Controllers
{
    public class HelloWorldController : Controller
    {
        // GET: /HelloWorld/
        public string Index()
        {
            return "This is my default action...";
        }

        // GET: /HelloWorld/Welcome/ 
        public string Welcome()
        {
            return "This is the Welcome action method...";
        }
    }
}
```
Now we have two action methods to work with, `Index` and `Welcome`. Go ahead and practice navigating to these actions now. Note that every *Public* method in a *Controller* is callable as an HTTP endpoint.

Next, let's investigate how *Parameters* work. We saw above that parameters are the third part of our URL route. We will modify the `Welcome` method so that it will allow us to pass a name and number into the URL. Modify your code as follows:
```c
public string Welcome(string name, int numTimes = 1)
{
    return HtmlEncoder.Default.Encode($"Hello {name}, you have visited {numTimes} times.");
}
```
> The code above uses HtmlEncoder.Default.Encode to protect the app from malicious input (namely JavaScript). The string format shown (using bracket notation for variables) is called *Interpolated Strings*.

Now we can use the following URL to pass our additional parameters to the action: `http://localhost:5000/HelloWorld/Welcome?name=Corey&numtimes=4`

In this example, the URL segment `Parameters` is not used. `Name` and `numTimes` as passed as *query strings*, where the question mark `?` marks the beginning of query strings, and the `&` seperates each query string parameter.

**Challenge:** How could we replace `numTimes` and use the route parameter `id` instead?

##### Microsoft Movie Example
From here, we will start using the Movie Application example from Microsoft. This will be a good resource for us because of how thoroughly each step of the example is documented. Also, many examples and question-answer posts regarding `ASP.NET MVC` are framed around this project, so that is another good reason to be familiar with it.

We will work  through this example project together. Follow the link below:

URL: http://docs.asp.net/en/latest/tutorials/first-mvc-app/adding-view.html#
