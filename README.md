### **Session 1**

We have discussed about automation:
  1. What is it
  2. Why is important
  3. Types of automation testing

The presentation will be sent via email at the end of this course.

### **Session 2:  Let's write our first UI automation tests**

**Scope:** This session scope was to create a unit test project, install all the dependencies and write some simple tests

How to create a unit test project:
  1. Open Visual studio
  2. Click File > New > Project
  3. Search for unit test: Unit Test Project(.NET Framework)
  4. Add project Name
  5. Click OK button
  
At this moment, we have created a unit test project and should have a default test class: UnitTest1. 
The class has the following particularities: 
1. It has [TestClass] annotation that identifies the class to be a test one. Without this annotation, the test under this class cannot     be recognized and there for cannot run the tests within it.
2. The class contains a test method that has a [TestMethod] annotation. This help the method to be recognized as an test method and run it accordingly.
  
Find more info on: https://docs.microsoft.com/en-us/visualstudio/test/walkthrough-creating-and-running-unit-tests-for-managed-code?view=vs-2019
  
Let's import the needed packages in order to open a chrome browser using our test. Do a right click on the created project and 
click Manage Nuget Packages. On the opened window, select Browse tab and search for Selenium.Webdriver and install it in your project. Then search for Selenium.Webdriver.ChromeDriver and install the latest version(avoid the ones that are in betha). 

Be aware that if the local installed Chrome is not the same with the installed package, it will trigger a compatibility error when running the test.
  
Let's write some code :) 
  
**REMEMBER: THE TEST DOES WHAT YOU TELL IT TO DO.**
Thats why, selenium manipulates the elements in DOM as a human would do. For now, we will use click and sendkeys.
  
Our first automated test case will try to login into application. For this, we will need a write code for the next steps:
  1. Open the browser
  2. Maximize the page
  3. Open the application URL
  4. Click Sign in button
  5. Fill user email
  6. Fill user password
  7. Click Sign in button 
  8. Assert that the current user label contains our email
    
Open the UnitTest1 class and let instantiate our driver to open the Chrome browser.

```csharp  
      var driver = new ChromeDriver(); //open chrome browser
      driver.Manage().Window.Maximize(); //maximize the window
      driver.Navigate().GoToUrl("OUR URL"); //access the SUT(System Under Test) url. In our case http://a.testaddressbook.com/
```

Until now, we have covered the first 3 steps of our test. Let's complete our test:

```csharp  
      driver.FindElement(By.Id("sign-in")).Click();
      Thread.Sleep(1000);
      driver.FindElement(By.Id("session_email")).SendKeys("email that was used for creating the account");
      driver.FindElement(By.Name("session[password]")).SendKeys("password used to create the account");
      driver.FindElement(By.CssSelector("input[value='Sign in']")).Click();
      Thread.Sleep(2000);
      Assert.AreEqual("asd@asd.asd", driver.FindElement(By.XPath("//span[@data-test='current-user']")).Text);
```

Clarification :)
  1. WebElement represents a DOM element. WebElements can be found by searching from the document root using a WebDriver instance. WebDriver API provides built-in methods to find the WebElements which are based on different properties like ID, Name, Class, XPath, CSS Selectors, link Text, etc.
  2. There are some ways of optimizing our selectors used to identify the elements in page.  
      a. For the CssSelector, the simplest way is to use the following format: tagname[attribute='attributeValue'].  
      b. For the XPath, the simplest way is to use the following format: //tagname[@attribute='attributeValue'].  
    Let's take for example the Sign in button:
    
```csharp    
    <input type="submit" name="commit" value="Sign in" class="btn btn-primary" data-test="submit" data-disable-with="Sign in">
```

    Explained: 
```csharp    
    <input(this is the tagname) 
        type(this is the attribute)="submit"(this is the value) --> The CssSelector would be: input[type='submit']
        name(this is the attribute)="commit"(this is the value) --> The XPath would be: //input[@name='commit']
        value(this is the attribute)="Sign in"(this is the value) --> The CssSelector would be: input[value='Sign in']
        class(this is the attribute)="btn btn-primary"(this is the value) --> The XPath would be: //input[@class='btn btn-primary']
        data-test(this is the attribute)="submit"(this is the value) --> The CssSelector would be: input[data-test='submit']
        data-disable-with(this is the attribute)="Sign in"(this is the value) --> The Xpath would be: //input[data-disabled-with='Sign in']
    >
```   
