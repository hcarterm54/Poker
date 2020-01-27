# Poker
A simple poker application
1. Start application
2. Provide input
3. Expected results

Solution design
I built out a suite of unit tests around the rules to determine Rank value for a hand, then began writing code to get the tests to pass.
I used enums to provide human readable values for ranking, face, and suit values. 

Entities
Card
Represents a playing card with a face value and a suit. No behavior is needed for this type.

Hand
A collection of Cards
I made the decision that the Hand class perform the sort.
Properties:
Cards – this property is a collection of Card objects.
I decided for this iteration not to incorporate validation in the object but to assume that the caller has already validated. The reason for that is that this object can’t know what cards would be in a different hand. The “dealer” should be responsible for ensuring valid cards are being dealt to each hand.
Ranking – this is the overall value of the hand. Create a service class to handle this, which means if it is used for a game with different rules in the future, a new implementation can be swapped in.
High card – last Card in the sorted collection.
Behavior
Methods implemented for sorting and comparison. I implemented the Icomparable<T> interface which simplified code for picking a winner in the applciation.
Service Classes
Hand Evaluator
This class sets the Ranking property of a Hand, which will be used for comparison purposes to determine the winner. 
Methods 
Create a histogram to determine group rankings – pair, two pair, three of a kind, full house, four of a kind.
Evaluate frequency of suits to determine flush ranking
Evaluate card sequencing to determine straight ranking.
Hand Services
BuildHand accepts an array of strings which are parsed into Card objects.

Hand Compare
This class compares two hands to determine highest value – the winner.
Implement Icomparable<Hand> in the Hand class
