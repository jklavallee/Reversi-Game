//AP CS Summer Assignment: Othello/Reversi by Jade Lavallee 2020

//Explanation/Guide for when reading my code:

// Globals: incr = increments for cases 1 and 2 --> pieces in the chain
// --> nextR = next row --> nextC = next column --> player0 = current black pieces --> player1 = current white pieces
//
//unfortunately the button array must be local to avoid complications, so it gets quite repetitive

//Invisible Button ba serves as a buffer piece/insulation for button array to avoid complications at edge and corner Buttons
//--> (there were other ways of approaching it, such as adding more conditional statements, but this was an ez fix for me)

//I could shorten my code and make it simpler but I wanted to add more stuff