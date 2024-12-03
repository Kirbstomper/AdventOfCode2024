For this problem I solved it using regex to filter the list in both parts.

I did my regex from within my editor so there isnt much to commit!

Part 1:

Filter to only mul(num1, num2) operations

mul\(\d*,\d*\)

Then filter to only the factors comma deliminated

\d*,\d*\



part 2:

Filter all mul, do, and don'ts
do\(\)|mul\(\d*,\d*\)|don't\(\)

find and remove all don'ts, along with anything until a do is hit ( i did this manually because lazy)
don't\(\)

Filter to only mul(num1, num2) operations

mul\(\d*,\d*\)

Then filter to only the factors comma deliminated

\d*,\d*\

