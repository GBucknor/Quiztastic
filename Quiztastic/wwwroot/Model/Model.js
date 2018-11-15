var quizContainer;
var resultsContainer;
var submitButton;
var saveButton;
var counter;
var myJSON;

var myQuestions = [
	{
		question: "What is 10/2?",
		answers: {
			a: '3',
			b: '5',
      c: '115',
      d: '666'
		},
		correctAnswer: 'b'
	},
	{
		question: "What is 30/3?",
		answers: {
			a: '3',
			b: '5',
      c: '10',
      d: '666'
		},
		correctAnswer: 'c'
    },
    {
		question: "What is 49/7?",
		answers: {
			a: '3',
			b: '5',
      c: '7',
      d: '666'
		},
		correctAnswer: 'c'
    },
    {
		question: "What is 3+4?",
		answers: {
			a: '7',
			b: '5',
      c: '9',
      d: '666'
		},
		correctAnswer: 'a'
    },
    {
		question: "What is 9-2?",
		answers: {
			a: '3',
			b: '5',
      c: '7',
      d: '666'
		},
		correctAnswer: 'c'
	}
];