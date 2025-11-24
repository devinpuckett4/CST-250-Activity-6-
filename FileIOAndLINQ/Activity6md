[Devin Puckett]

[CST-250 Programming in C#2]

[Grand Canyon University]

[11/23/2025]

[Activity 6]

[https://github.com/devinpuckett4/CST-250-Activity-6/blob/main/Activity6.md]

[https://www.loom.com/share/52ac23357b9e47c38276ed37796cfe9d]






FLOW CHART
 

Figure 1: Flow chart Activity 6 

This flowchart shows the main loop of my Bible verse application from the user’s point of view. The program starts and opens the FrmVerseList form, which also loads any verses that were previously saved. Then it waits for a user action, like adding a verse, saving, loading, or filtering the list. Whatever the action is, it gets passed to VerseLogic, which does the real work with the data layer and file serialization. After the logic finishes, the DataGridView is refreshed so the user can see the updated verses, and then the user can either keep working in the app or close it, which repeats this cycle until they exit.



UML Class Diagram
 
Figure 2: UML Diagram 

For this diagram, I tried to show how my Bible verse app is split into layers and how the data flows between them. On the left is FrmVerseList, which is the WinForms screen the user interacts with. It just handles events like button clicks, menu items, and the trackbar, then calls into the logic layer and refreshes the grid. In the middle is VerseLogic, which acts as the “brain” of the program. It takes a VerseRequestModel from the form, does the work to add or filter verses, and returns a list of VerseDisplayModel objects that are easy to show on the screen. On the right is VerseDAO, which is the data access class that actually stores the verses in a list of VerseDataModel objects and handles saving and loading from a file. The dashed arrows show how each layer uses a different model, which keeps the UI, logic, and data clearly separated.


 
Figure 3: Bible Verse App Running

This screenshot shows the main screen of my Bible verse app. On the left I have an area called Add A Bible Verse where I can choose the book and type in the chapter, verse, the verse text, and a short meaning. I can also pick how important the verse is from 1 to 10 and then click Add Verse to save it. On the right there is a filter section where I can choose to see all verses or only the least or most important ones. At the bottom you can see the list of saved verses with John 1:1 already added, showing the verse text, my meaning, and an importance value of 10.

Figure 4: Method Of Add Verse
 
This screenshot shows the AddVerse method in my logic class. The method receives a verse request and first checks if the request is empty. If it is empty it sends back a message that the verse was not added. If the request has data the code builds a new VerseDataModel and fills in the id book chapter verse text meaning and importance fields from what the user typed on the form. Then it calls the data access layer to save that verse and returns a message that the verse was added. This ties the user input on the screen to the list of verses stored in the program.
 
Figure 5: Error Handling on AddVerse
This screenshot shows the Add A Bible Verse section with the validation errors turned on. The fields for book, chapter, verse, meaning, and importance all have small red stars next to them to show they are required. This happens when I try to add a verse without filling everything in correctly. It makes it clear to the user which inputs still need attention before the verse can be saved. This helps prevent bad or incomplete data from being added to the list.
 
Figure 6: Add Verse in App

This screenshot shows me adding a new Bible verse to the app. I have selected the book of Romans and entered chapter seven verse nineteen along with the full verse text and my own explanation of its meaning. The importance level is set near the high end before I click the Add Verse button. In the middle of the screen a message box pops up saying that the verse was added and that the verses were saved to the json file, which confirms that both the in memory list and the file storage were updated. At the bottom you can still see the grid showing the verse that was already saved earlier.


Figure 7: Screenshot verses.json Saved File
 
This screenshot shows the verses.json file where my app saves all of the Bible verses. Each block of text is one verse and includes the id, book, chapter, verse number, the full verse text, my own meaning, and the importance rating from 1 to 10. You can see examples from John chapter 1 verse 1, Romans chapter 7 verse 19, and John chapter 3 verse 16 already stored in the file. This proves that when I add a verse in the program it is written out to a real file on disk and can be loaded again later. It shows the data is not just in memory but is being kept between runs of the application.



Figure 8: Screenshot Least Important
 This screenshot shows my Bible verse app using the filter features. The Add A Bible Verse section on the left is cleared out and ready for a new entry, with the book set to Genesis and the other fields empty. On the right I have chosen Show Least Important and the slider is set to one, so it will only display the single verse with the lowest importance value. At the bottom of the screen the grid now shows just Romans 7:19 with its text, meaning, and an importance rating of nine. This demonstrates that the filter and slider work together to control which verses are shown in the list.

 
Figure 9: Screenshot Showing Most Important/Slider Functional

This screenshot shows the app with the filter set to Show Most Important. The Add A Bible Verse section is cleared and ready for a new entry, with the book set to Genesis. On the right the Show Most Important option is selected and the slider is set to three, which means I want to see the three verses with the highest importance ratings. At the bottom the grid lists John 1:1, John 3:16, and Romans 7:19 along with their text, meanings, and importance values. This demonstrates that the app can sort and display the verses based on what I marked as most important.

 
Figure 10: Load Saved Verses

This screenshot shows the app after I have used the Load menu option to bring verses back in from the saved file. The message box in the center explains that the verses were loaded from verses dot json and shows the full folder path on my computer. Behind the message box the grid at the bottom lists John 1 1 John 3 16 and Romans 7 19 which confirms that all of the saved verses were read in correctly. This proves that my data access code can open the json file on disk and repopulate the in memory list and user interface.








Figure 11: Saved File .json
 
This screenshot shows my app after I choose the option to save all of the verses. The message box in the center explains that the verses were saved to a file named verses dot json and it shows the full folder path where the file was written on my computer. In the background the grid still lists John 1 1 John 3 16 and Romans 7 19 along with their text, meanings, and importance values. This confirms that everything currently shown in the list has been stored safely so it can be loaded again the next time I run the program.







Figure 12: Final 

 
This screenshot shows the completed version of my Bible verse application. The Add A Bible Verse section on the left is ready for a new entry, with the book set to Exodus and the other fields cleared out, and the importance set to three by default. On the right the Filter And Sort area is set to Show All, and the slider is positioned so the labels for least and most important both show five. At the bottom the grid now contains several saved verses including John 1 1, Romans 7 19, John 3 16, Genesis 2 1, and Jonah 2 10 along with my explanations and importance values. This final view shows that my app can hold multiple verses at once and that all of the add, save, load, and filter features are working together.








ADD ON



1.	What was challenging?
The most challenging part of Activity 6 was keeping the file handling and filtering logic working together without getting lost in all the steps. I had to make sure the form collected the verse details, sent them to VerseLogic, and then VerseDAO saved them out to the json file correctly. On top of that, the filter options for most important and least important verses depended on the LINQ methods returning the right data. If one piece was off, like the binding source not being refreshed or the track bar not matching the number of verses, the grid would not show what I expected. It forced me to slow down and check each layer to see where the problem really was.

2.  What did you learn?
I learned a lot about working with files and how powerful it is to let the logic layer control that instead of doing everything in the form. Saving and loading the verses to a single json file showed me how to keep data around even after the program closes. I also learned how LINQ can be used to quickly sort and pick out the most important or least important verses without writing long loops. The validation with regular expressions taught me how to protect the app by making sure the chapter and verse fields are in a proper format before anything is saved. Overall, I saw how the layers and tools work together in a cleaner way than trying to cram it all into one class.
3.  How would you improve on the project?
If I had more time, I would add better feedback on the screen when filters are active, maybe a label that clearly explains what is being shown. I would also like to add editing and deleting so a user can fix a verse instead of only adding new ones. Another improvement would be to let the user choose between json, csv, or text when saving and show which format is currently in use. It would also be nice to support simple searching, such as typing a word and showing only verses whose text or meaning contains that word. These changes would make the Bible verse tool feel more complete and easier to use every day.

4.  How can you use what you learned on the job?
What I learned in this activity fits directly with how many business applications work behind the scenes. Reading and writing to files, validating input, and using LINQ to sort or filter data are all things that show up in reporting tools, small inventory systems, and internal tracking apps. Knowing how to keep file access in a data layer and not mix it into the UI will help me write cleaner code that other developers can understand and maintain. The experience of tracing bugs across the presentation, logic, and data layers also trained me to debug step by step instead of guessing. Those skills will be useful on any job where I need to handle user input, store information safely, and present it back in a clear way.




