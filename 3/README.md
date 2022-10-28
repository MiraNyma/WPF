# Task 3

## Part 1
On this folder you can find the **DrawShapes**-folder. That contains the source code for a simple C# WPF app, where you should be able to draw circles and squares to a Canvas placed on the apps MainWindow.

On Visual Studio, you should able to view and edit the basic UI template by double-clicking the **MainView.xaml**. In this view you should be able to see both the visual representation of the UI as well as the XAML-structure and edit their properties as well. See screenshot below:

![IntelliSense](/../master/Images/1_P0.PNG?raw=true)

On the bottom of the screenshot, on the last 2 lines of the XAML-code, theres' the initialization of the **Canvas**-control. The only setting included in it is the **x:Name** so that we can access it in our C#-code by using the name. Other ways to access elements is to bind data or the children to certain elements. We will cover that in later exercises.

Now open the **DrawShapes**-project in your Visual Studio, if you have not done that yet. Then find the C#-code in the **MainView.xaml.cs**

![IntelliSense](/../master/Images/1_P2.PNG?raw=true)

Notice that the classes **BoxArea** and **CircleArea** are empty and you should see some errors in the code as well. You need to create the required properties for both classes and then hit start. 

```
CreateBox(new BoxArea() { X = 50, Y = 50, Height = 100, Width = 80 });
CreateBox(new BoxArea() { X = 200, Y = 200, Height = 40, Width = 200 });

CreateCircle(new CircleArea() { X = 300, Y = 300, Radius = 50 });
CreateCircle(new CircleArea() { X = 100, Y = 200, Radius = 100 });
```

After that you should see 2 squares appear, but if you check the **MainWindow**-method, you should see that there's the above 4 lines of code in it. If you look more closely, you should notice that it tries to create 2 squares and 2 circles. The square-drawing works, but you need to implement the functionality of the **CreateCircle**.

Once your code works completely, you should see something like this on the app once it's started:

![IntelliSense](/../master/Images/1_P1.PNG?raw=true)

So in conclusion:
1. Open the DrawShapes-project
2. Open MainView.xaml.cs
3. Create properties for BoxArea and CircleArea (and fix the errors in the code by doing so)
4. Create the functionality for CreateCircle (See more info from Google by searching for **WPF Draw Ellipse to Canvas**)
5. ????
6. Profit

Once you reach point 6, use **git commit and push** to upload your changes.

## Part 2

Now that you have create the functionality to draw the circle, add another shape drawing in your code. Add atleast **DrawTriangle** and **DrawDiamond**. Add also new classes for, the same way as for the Circle and Square.

Draw all the new shapes you have created to your app and then use **git commit and push** to merge your changes.