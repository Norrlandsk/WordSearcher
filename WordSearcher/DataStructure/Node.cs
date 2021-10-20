namespace WordSearcher.DataStructure
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    internal class Node
    {
        private int value;
        private Node rightNode;
        private Node leftNode;

        //Constructor
        public Node(int value)
        {
            this.setValue(value);
        }

        //Getters and setters below
        public int getValue()
        {
            return value;
        }

        public void setValue(int newValue)
        {
            this.value = newValue;
        }

        public Node getRightNode()
        {
            return this.rightNode;
        }

        public void setRightNode(Node newNode)
        {
            this.rightNode = newNode;
        }

        public Node getLeftNode()
        {
            return this.leftNode;
        }

        public void setLeftNode(Node newNode)
        {
            this.leftNode = newNode;
        }

        //ToString for printOut
        public String toString()
        {
            String outputString = "Value: " + getValue();
            if (getLeftNode() != null)
            {
                outputString += "\n" + "LeftNode: " + getLeftNode().getValue();
            }
            else
            {
                outputString += "\n" + "LeftNode: Empty";
            }
            if (getRightNode() != null)
            {
                outputString += "\n" + "RightNode: " + getRightNode().getValue();
            }
            else
            {
                outputString += "\n" + "RightNode: Empty";
            }

            return outputString;
        }
    }
}