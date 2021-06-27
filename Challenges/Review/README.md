# Develop Challenge

This challenge is to review the code in the event logger application.

# Requirements

Review the code in the Logger.cs class and suggest any ammendments you feel should be made to improve the code. Fill in your suggestions and reasoning below.

| Line(s) | Suggested Change | Reasoning |
|---------|------------------|-----------|

19,22 | line 22 move to under line 15 | EventSourceB has no event handler and will throw an error
40 | remove static from method | static is not needed for this method
42 | rm should be changed to rnd | make random variable name easier to understand
43,47 | j should be changed to another value from 0 | right shift on 0 will result in 0 and will always result in the same value, logic is needs ammending
45 | lt should be changed to it | not sure what lt stands for, it - iteration
45 | =0 to = 0 | make sure the code is easy to read, comments also needed
53 | Add code to abstract method Dispose | interfce methods need to be implemented