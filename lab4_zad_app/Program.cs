using lab4_zad;

BothThings myNode = new("D:/test/");

myNode.PrintNode();
OrderByNameAndSize byName = new(myNode.files);
byName.PrintByName();
byName.PrintBySize();
OrderByFirstLetter byFirstLetter = new(myNode.files);
byFirstLetter.PrintByFirstLetter();
ByTypes byTypes = new(myNode.files);
byTypes.Print();
BySizes bySizes = new(myNode.files);
bySizes.PrintBySizes();
ByExtension byExtension = new(myNode.files);
byExtension.PrintByExtension();





