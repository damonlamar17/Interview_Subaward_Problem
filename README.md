# Interview Subaward Processor Problem

This is Damon LaMar's Interview Project for the Software Engineering position with Sponsored Programs Administration

## Assumptions Made

-The Subaward row always includes the Keyword "Subaward" in the row text
-The subaward row has only one money amount that can be parsed as a decimal
-Only the 4 stated subrecipients are required even though there are more values than that
-The subrecipients won't have multiple names that contain the same words ex. Florida vs Florida State
-All excel files will be in an .xlsx format and we won't be handling other spreadsheet types like csv or .xls


## Questions

-Are spreadsheet formats going to be consistent for all future files to parse?
-How does this program fit into our system and how does it run for the users?
-Is there the possibility of increasing the number of subrecipients we are looking for?
-Will this just be used for small batches of spreadsheets or will it need to be able to handle hundred of files?
-What happens when there are two seperate subrecipients that both contain a defined subrecipient name ex. Florida vs Florida State?
