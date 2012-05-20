sqlite-metrostyle
=================

C++/CX implementation of SQLite. Kept up-to-date with latest SQLite drop.

Build instructions
===

From @timheuer's instructions at https://skydrive.live.com/view.aspx?resid=A737583042956228!1940&cid=a737583042956228.

The following is needed in order to build SQLite successfully:  
Some C compiler.  For most, this will be easiest to just have a version of Visual Studio 11 installed  
VS command prompt (you will be doing all from here)  
Tcl for Windows: http://www.activestate.com/activetcl/downloads (8.5 or higher)  
Note: when installing this, just let it install to default location (c:\tcl)  
http://unxutils.sourceforge.net/UnxUpdates.zip  
Make sure these are in your VS command prompt path  
Fossil (source control for SQLite - like Git) http://www.fossil-scm.org/download.html  
Make sure the fossil.exe is also in your VS command prompt path  
Tutorial: http://fossil-scm.org/index.html/doc/trunk/www/quickstart.wiki  
 
 
DO NOT TRY THIS UNLESS YOU'VE ACQUIRED ALL TOOLS FROM STEP 1!!  
Start a VS command prompt as admin  
Note, whatever arch you are starting as is the bitness that will be created  
Navigate to where you want to put the source or create a directory  
Ex: Mkdir c:\sqlite  
Get the latest source code:  
fossil clone http://www.sqlite.org/cgi/src sqlite3.fossil  
If you have a proxy server first set the proxy: fossil setting proxy[proxyurl]  
Open the repository you just created:  
fossil open sqlite3.fossil  
Get the desired source branch (example getting the WinRT branch):  
fossil checkout winrt  
Build the DLL:  
nmake -f makefile.msc sqlite3.dll FOR_WINRT=1  
The resulting binary will be sqlite3.dll, sqlite3.lib, sqlite3.pdb, sqlite3.h (with the almagamation of sqlite3.c)