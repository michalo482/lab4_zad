using lab4_zad;

BothThings myNode = new("D:/test/");

myNode.PrintNode();
OrderByNameAndSize byName = new(myNode.files);
byName.PrintByName();
byName.PrintBySize();
OrderByFirstLetter byFirstLetter = new(myNode.files);
byFirstLetter.PrintByFirstLetter();



