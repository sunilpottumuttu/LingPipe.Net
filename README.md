Developers Guide to LingPipe on .NET
===============================

This project is a simple wrapper around the very excellent Java Library [LingPipe](http://alias-i.com/lingpipe/) which is used for processing text and computational linguistics.



##How I Built lingpipe-app  .NET Assembly##

1. Downloaded [IKVM](http://www.ikvm.net/) . 
2. Extracted the zip file to IKVM Directory
3. From the command prompt executed the following command
ikvmc.exe -target:library -assembly:lingpipe-app -classloader:ikvm.runtime.AppDomainAssemblyClassLoader lingpipe-4.1.0.jar
4. The resultant is .net Assembly and reference in my Visual Studio Solution

##Demo Application##

I have Included a Demo Application which is a Visual  Studio Solution.

