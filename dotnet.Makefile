SOLUTION_NAME = RomanNumerals
TEST_PROJECT = RomanNumeralsTest
LIB_PROJECT = RomanNumerals

build:
	dotnet build $(SOLUTION_NAME).sln

test:
	dotnet test $(TEST_PROJECT)/$(TEST_PROJECT).csproj

clean:
	dotnet clean $(SOLUTION_NAME).sln

restore:
	dotnet restore $(SOLUTION_NAME).sln

rebuild: clean restore build

setup:
	dotnet new sln --name $(SOLUTION_NAME)
	dotnet new classlib --framework "netstandard2.0" --output $(LIB_PROJECT)
	dotnet sln $(SOLUTION_NAME).sln add $(LIB_PROJECT)/$(LIB_PROJECT).csproj
	dotnet new xunit --framework "net7.0" --output $(TEST_PROJECT)
	dotnet sln $(SOLUTION_NAME).sln add $(TEST_PROJECT)/$(TEST_PROJECT).csproj
	dotnet add $(TEST_PROJECT)/$(TEST_PROJECT).csproj reference $(LIB_PROJECT)/$(LIB_PROJECT).csproj

.PHONY: build test clean restore rebuild
