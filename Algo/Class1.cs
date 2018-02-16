using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stosik;

namespace ONP1
{       //--------------------- STACK === LIFO =====LAST IN   FIRST OUT
    public class naOnp
    {
        public string Stworz(string cal)
        {
            string text = cal; //allright so here i have a a..text
            text = text.Replace(" ", "");
            Stack<char> stos = new Stack<char>();
            string output = ""; //this is a simple text thanks to this i will be able to write everythin here

            for (int i = 0; i < text.Length; i++) //i will do loop so long as this text has letters in it
            {
                //allright let's think what should i do know .... i surely need to download a letter from that text so..
                char letter = text[i]; //great so i just write a letter right there
                //now do i need to create a loop hm... no not really i just download one letter why should i create a loop???
                switch (letter)
                {
                    case '(': stos.Push(letter); break; //if i will meet opening bracket i going to put this on stock
                    case ')': while (stos.Peek() != '(') { output = output + " " + stos.Pop(); } if (stos.Peek() == '(') { stos.Pop(); } break;//what will happen if there will be closing bracket
                    case '+':
                        if (stos.Peek() == '(' || stos.Count() == 0) stos.Push(letter);
                        else if (stos.Peek() != '+' || stos.Peek() == '+')
                        {
                            while (stos.Count() != 0) { output = output + " " + stos.Pop(); if (stos.Count() == 0 || stos.Peek() == '(') break; }
                            stos.Push(letter);
                        }
                        break;

                    case '-':
                         if (stos.Peek() == '(' || stos.Count() == 0) stos.Push(letter);
                        else if (stos.Peek() != '-' || stos.Peek() == '-')
                        {
                            while (stos.Count() != 0) { output = output + " " + stos.Pop(); if (stos.Count() == 0 || stos.Peek() == '(') break; }
                            stos.Push(letter);
                        }
                        break;

                    case '*':
                         if (stos.Peek()=='+' || stos.Peek()=='-' || stos.Peek()=='(' || stos.Count() == 0) { stos.Push(letter); }
                        else if (stos.Peek() == '*' || stos.Peek() == '/' || stos.Peek() == '%' || stos.Peek() == '^')
                        {
                            while (stos.Count() != 0) { output = output + " " + stos.Pop(); if (stos.Count() == 0 || stos.Peek() == '+' || stos.Peek() == '-' || stos.Peek() == '(' || stos.Peek() == ')') break; }
                            stos.Push(letter);
                        }
                        break;

                    case '/':
                        if (stos.Peek() == '+' || stos.Peek() == '-' || stos.Peek() == '(' || stos.Count() == 0) { stos.Push(letter); }
                        else if (stos.Peek() == '*' || stos.Peek() == '/' || stos.Peek() == '%' || stos.Peek() == '^')
                        {
                            while (stos.Count() != 0) { output = output + " " + stos.Pop(); if (stos.Count() == 0 || stos.Peek() == '+' || stos.Peek() == '-' || stos.Peek() == '(' || stos.Peek() == ')') break; }
                            stos.Push(letter);
                        }
                        break;

                    case '%':
                        if (stos.Peek() == '+' || stos.Peek() == '-' || stos.Peek() == '(' || stos.Count() == 0) { stos.Push(letter); }
                        else if (stos.Peek() == '*' || stos.Peek() == '/' || stos.Peek() == '%' || stos.Peek() == '^')
                        {
                            while (stos.Count() != 0) { output = output + " " + stos.Pop(); if (stos.Count() == 0 || stos.Peek() == '+' || stos.Peek() == '-' || stos.Peek() == '(' || stos.Peek() == ')') break; }
                            stos.Push(letter);
                        }
                        break;
                    case '^':
                         if (stos.Peek() != '^' || stos.Count() == 0) { stos.Push(letter); }
                        else if (stos.Peek() == '^')
                        {
                            while (stos.Count() != 0) { output = output + " " + stos.Pop(); if (stos.Count() == 0 || stos.Peek()!='^') break; }
                            stos.Push(letter);
                        }
                        break;

                    default: if (output.Length == 0) output += letter;
                        else if (i > 0)
                        {
                            if (!((char.IsNumber(text[i - 1]))))
                            {
                                output = output + " " + letter;
                            }
                            else output += letter;
                        }
                        break;
                }
                if (i == text.Length - 1) //ostatnie opertory z listy
                {
                    while (stos.Count() != 0) { if (stos.Peek() == '(') { stos.Pop(); } output = output + " " + stos.Pop(); if (stos.Count() == 0) break; }
                }

            }
            Console.WriteLine(output);
            return output;
        }
    }
}

