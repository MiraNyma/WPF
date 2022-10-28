# Task 2

## Part 1
As on the first task, you will need to create a new WPF-application on your Visual Studio. Now instead of doing the same thing as on your tutorial, create an app which looks like this:

![IntelliSense](/../master/Images/4_P1.png?raw=true)

You can still follow some parts of the instruction found in MSDN-documentation for creating simple WPF applications in Visual Studio 2019. You can find the instructions from here: https://docs.microsoft.com/en-us/dotnet/framework/wpf/getting-started/walkthrough-my-first-wpf-desktop-application

Once user interface looks like the image above, use **git commit and push** to upload your changes.

## Part 2

Add some functionality to your app. Add these to the code in **MainWindow.xaml.cs**:
- Buttons *Pertti*, *Simo*, *Keijo* and *Raimo* show a messagebox with the message **Hei --Nimi--**, where the **Nimi** comes from the button text
- Buttons **Add item** and **Remove Item** add or remove items on the **Combobox** on the right. You can add items randomly, or just add the same text. 
- Every time the user presses a button, the bottom **ListBox** adds a new row for **Log** showing what has happened in the app. So print for example **Button Pertti was pressed**. Add also a timestamp for it.
- Add also additional log for buttons. The buttons on WPF apps allow you to monitor different events such as **MouseEnter**, **MouseMove** and **MouseLeave**. Add a line to the log view for those also.

After all the mentioned additions are working properly, use **git commit and push** to upload your changes.