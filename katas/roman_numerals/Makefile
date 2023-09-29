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

.PHONY: build test clean restore rebuild
