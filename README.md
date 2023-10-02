# Online Challenges
WithGoogle, LeetCode, URI solutions all in one place.
Here you can find how to build up and run the solutions using Python3, C, Java and Go.


## Python3
### testing 
pytest file.py

### using main.py to debug
python3 main.py

### install virtualenv
python3 -m venv .

### activate virtual env
. ./bin/activate
### deactivate
deactivate

### install requirements
python3 -m pip install -r requirements.txt

## .NET
### testing
dotnet test
#### run specific classes or methods
dotnet test --filter "FullyQualifiedName=Namespace.ClassName.MethodName"
dotnet test --filter "FullyQualifiedName~Namespace.Class"
### setting solution to start katas and challenges
#### creates a sln with directory name
dotnet new sln 

#### check sdk versions
dotnet sdk check

#### create new project
dotnet new classlib --framework "netstandard2.0" --output RomanNumerals

#### add project to solution
dotnet sln roman_numerals.sln add RomanNumerals/RomanNumerals.csproj
#### create and add test project to the solution
dotnet new xunit --framework "net7.0" --output RomanNumeralsTest
dotnet sln roman_numerals.sln add RomanNumeralsTest/RomanNumeralsTest.csproj

#### Adding references and packages
- package
dotnet add package Microsoft.EntityFrameworkCore
dotnet add ToDo.csproj package Microsoft.Azure.DocumentDB.Core -v 1.0.0
- adds project-to-project (P2P) references
dotnet add RomanNumeralsTest/RomanNumeralsTest.csproj reference RomanNumerals/RomanNumerals.csproj
