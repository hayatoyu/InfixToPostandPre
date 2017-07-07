using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfixtoPostandPre
{
    class Infix
    {
        private int priority(char c)
        {
            return (c == '+' || c == '-') ? 1 : ((c == '/' || c == '*') ? 2 : 0);
        }

        private string toPostfix(string input,bool isPost)
        {
            string expr = isPost ? input : StringReverse(input);
            Stack stack = new Stack();
            StringBuilder stbr = new StringBuilder();
            char toStack = isPost ? '(' : ')';
            char toOutput = isPost ? ')' : '(';

            for(int i = 0;i < expr.Length;i++)
            {
                if (expr[i] == toStack)
                    stack.Push(expr[i]);
                else if ("+-*/".IndexOf(expr[i]) != -1)
                {
                    while(stack.Count > 0 && priority((char)stack.Peek()) >= priority(expr[i]))
                    {
                        stbr.Append(stack.Pop());
                    }
                    stack.Push(expr[i]);
                }
                else if (expr[i] == toOutput)
                {
                    while((char)stack.Peek() != toStack)
                    {
                        stbr.Append(stack.Pop());
                    }
                    stack.Pop();
                }
                else
                {
                    stbr.Append(expr[i]);
                }
            }

            while (stack.Count > 0)
                stbr.Append(stack.Pop());
            return isPost ? stbr.ToString() : StringReverse(stbr.ToString());
        }
        private string StringReverse(string input)
        {
            char[] cArray = input.ToCharArray();
            Array.Reverse(cArray);
            return new string(cArray);
        }

        public string toPrefix(string input)
        {
            return toPostfix(input, false);
        }

        public string toPostfix(string input)
        {
            return toPostfix(input, true);
        }
    }
}
