sqlite-metrostyle
=================

C++/CX implementation of SQLite. Kept up-to-date with latest SQLite drop.

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