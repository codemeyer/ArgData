# Contributing

## Contributing research material

If you have any research material about the structure of the GP.EXE, F1PREFS.DAT or the F1CTxx.DAT track data files, you are welcome
to contact the owner of this repository.


## Contributing code

When contributing code to this repository, please first discuss the change you wish to make via issue, email,
or any other method with the owners of this repository before making a change.

Any new code must adhere to the current code style.

Any new code must have tests with complete coverage.

New API code must support at least F1GP _and_ World Circuit 1.05.


### Getting started

After cloning the repo you will need to download some binary test files before you can run any of the tests. See below.


### Notes about test files

Several tests use actual copies of the GP.EXE and other data files for reading and writing. To avoid bloating the
repository with binary files, the files used in the tests must be downloaded before the tests can run.

Go to the TestFiles folder and execute ./Download.ps1 in a PowerShell console. This will download the latest version
of the test files as a .zip file and unpack them. The .zip file is currently hosted in a public Dropbox folder.

If you add code that requires a new binary file to be included in the test files zip, contact the owner of this
repository to make sure that the binary file is included in future downloads of the .zip file.


### Pull Request Process

1. Ensure all code builds and tests are green.
2. Update the README.md with details of changes if necessary.
3. Update API documention in the Docs folder if necessary
