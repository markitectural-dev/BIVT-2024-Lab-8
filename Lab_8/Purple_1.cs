using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8 {
    public class Purple_1 : Purple {
        private string _output;
  
        public string Output => _output;

        public Purple_1(string input) : base(input) {}

        private void ReverseStringBuilder(StringBuilder array, int startIndex, int lastIndex) {
            if (startIndex < 0 || lastIndex >= array.Length) return;

            while (startIndex < lastIndex) {
                (array[startIndex], array[lastIndex]) = (array[lastIndex], array[startIndex]);
                startIndex++;
                lastIndex--;
            }
        }

        public override void Review() {
            if (string.IsNullOrEmpty(Input))  {
                _output = Input;
                return;
            }
            
            var resultString = new StringBuilder(Input);
            var startIndex = -1;
            var nextIsPunctOrSpace = false;

            for (int i = 0; i < Input.Length; i++) {
                bool isLetter = IsInWord(Input[i]);
                nextIsPunctOrSpace = isValidDelimiter(Input[i]) || (isLetter && i == Input.Length - 1);

                if (isLetter && startIndex == -1 && ((i > 0 && isValidDelimiter(Input[i - 1])) || i == 0)) {
                    startIndex = i; 
                }
                
                if (nextIsPunctOrSpace && startIndex > -1) {
                    ReverseStringBuilder(resultString, startIndex, isLetter ? i : i - 1);
                    startIndex = -1;
                }
            }

           _output = resultString.ToString();
        }

        public override string ToString() {
            return _output;
        }
    }
}