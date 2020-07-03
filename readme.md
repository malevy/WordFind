# WordFind

### Another puzzle solver project

I came across a list of 370K+ english words while cruising around github.
It occurred to me that I could use the list to solve a couple types of word
problems. Given a set of letters, this project will identify all the words
that can be created from them. You could, for example, cheat at Scrabble
or unscramble a word. 

##### Please note
in the event that see some strange words being returned, there's a good chance
that they exist in the word list.

#### Sample call
GET /api/words?from="yobt" HTTP/1.1
Host: ...
Content-Type: text/plain

The results will be returned as an array of strings

Word list provided by dwyl.com https://github.com/dwyl/english-words