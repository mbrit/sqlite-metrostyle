sqlite-metrostyle - Build of sqlite3 library validated against the Windows App Certificaiton Kit
===
The objective of this project is to create a sqlite3.dll that WinRT/Metro-style developers can use with confidence.

SQLite.org have given their commitment to having SQLite work property in Metro-style apps. The code now contains
a `SQLITE_OS_WINRT` preprocessor directive within their main code branch. This project takes the
"amalgamated" sqlite3.c file and compiles the project with that preprocessor directive switched on. We then
take that DLL and use it within a normal C#/XAML Metro-style app whereupon we run the app through the 
Windows App Certification Kit. We use the [https://github.com/praeclarum/sqlite-net sqlite-net] driver within the
project to call SQLite - this being the recommended route.

You should note that this code uses a branch of the main SQLite source tree. SQLite.org typically only regards the
main branch as being officially supported.

You will generally *not* need to clone or download this repo to use it. Follow the instructions below.

To use SQLite in your C#/XAML project
===
Follow these steps:

* Create a new project
* From this repo, download the `~/bin/sqlite3.dll`. Save it somewhere on your machine.
* In the new project, right-click the project and select **Add Existing Item**. Find the sqlite3.dll and select it. You do *not* need to
add a reference to ths project. This may seem counterintuituve, but sqlite3.dll is not a WinRT component and hence isn't 
"referenced" in the usual way. The application packaging process will find any project items marked as **Content** and deploy
them with the app.
* Follow the instructions on sqlite-net about getting started. This will usually involve copying source code files into your project.
sqlite-net also isn't "referenced" into your project from an assembly - it's compiled in.

Once you've done that, you should be able to reference SQLite.

Marketplace validation
===
As mentioned above, we validate the DLL and the sqlite-net library ourselves before we commit into this repo. Here are
the runs that we have done. Validation reports are stored in the `~/ValidationReports` folder. Git tags are created for each committed 
run.

* sqlite3.dll, v3.7.12, 2012-05-20 - Consumer Preview, PASS with Launch and Suspend warnings (see notes)

If you're reproducing these tests you should note that validation always fails unless you are building in Release mode.

We're seeing "launch" and "suspend" warnings with the Consumer Preview whatever apps we run, hence we're assuming
that this problem will be ironed out closer to release. 

Original build instructions
===
On May 18th 2012, @timheuer's posted instructions on how to grab the WinRT branch from SQLite.org and
build a DLL that can be used with Metro-style apps.

**You generally won't need to follow these steps - this project does all this work for you!**

His original instructions are here: https://skydrive.live.com/view.aspx?resid=A737583042956228!1940&cid=a737583042956228.

For convenience, these are his instructions:

The following is needed in order to build SQLite successfully:  
* Some C compiler.  For most, this will be easiest to just have a version of Visual Studio 11 installed  
* VS command prompt (you will be doing all from here)  
* Tcl for Windows: http://www.activestate.com/activetcl/downloads (8.5 or higher)  Note: when installing this, just let it install to default location (c:\tcl)  
* http://unxutils.sourceforge.net/UnxUpdates.zip  Make sure these are in your VS command prompt path  
* Fossil (source control for SQLite - like Git) http://www.fossil-scm.org/download.html  
* Make sure the fossil.exe is also in your VS command prompt path  
  
DO NOT TRY THIS UNLESS YOU'VE ACQUIRED ALL TOOLS FROM STEP 1!!  
* Start a VS command prompt as admin  (Note, whatever arch you are starting as is the bitness that will be created)
* Navigate to where you want to put the source or create a directory  e.g, `Mkdir c:\sqlite`
* Get the latest source code: `fossil clone http://www.sqlite.org/cgi/src sqlite3.fossil` (If you have a proxy server first set the proxy: fossil setting proxy[proxyurl])
* Open the repository you just created:  `fossil open sqlite3.fossil`
* Get the desired source branch (example getting the WinRT branch): `fossil checkout winrt`
* Build the DLL:  `nmake -f makefile.msc sqlite3.dll FOR_WINRT=1`

The resulting binary will be sqlite3.dll, sqlite3.lib, sqlite3.pdb, sqlite3.h (with the almagamation of sqlite3.c)