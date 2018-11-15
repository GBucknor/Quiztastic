quizContainer = document.getElementById('quiz');
resultsContainer = document.getElementById('results');
saveButton = document.getElementById('save');
addButton = document.getElementById('add');
counter = 0;

function viewQuestions(questions, quizContainer) {
	// we'll need a place to store the output and the answer choices
	var output = [];
	var answers;

	// for each question...
	for(var i=0; i<questions.length; i++){
		
		// first reset the list of answers
		answers = [];

		// for each available answer to this question...
		for(letter in questions[i].answers){

			// ...add an html radio button
			answers.push(
                '<ul class="nobull">'
				+ '<li><label>'
					+ '<input type="radio" name="question'+i+'" value="'+letter+'">'
                    + '<input name="answer" type="text" value="'
                    + questions[i].answers[letter]
                    + '">'
                + '</label></li>'
                + '</ul>'
			);
		}

		// add this question and its answers to the output
		output.push(
            '<div class="question" contenteditable="true">'
                + questions[i].question + '</div></br>'
            + '<div class="answers">' + answers.join('') + '</div>'
            + '<div class="correctAnswer" contenteditable="true">' 
            + questions[i].correctAnswer + '</div></br>'
		);
    }

    output.push(
        '<div id="addons"></div>'
    )
	// finally combine our output list into one string of html and put it on the page
	quizContainer.innerHTML = output.join('');
}

addButton.onclick = function() {
    var add = document.getElementById("addons");
    var output;
    
        output =
            '<div id="addquestion' + counter + '" contenteditable="true">New Question</div></br>'
            + '<div class="addanswers' + counter + '">' 
                + '<ul class="nobull">'
				    + '<li><label>'
					    + '<input type="radio">'
                        + '<input name="addanswer" type="text" value="answer">'
                    + '</label></li>'
                + '</ul>' 
                + '<ul class="nobull">'
				    + '<li><label>'
					    + '<input type="radio">'
                        + '<input name="addanswer" type="text" value="answer">'
                    + '</label></li>'
                + '</ul>' 
                + '<ul class="nobull">'
				    + '<li><label>'
					    + '<input type="radio">'
                        + '<input name="addanswer" type="text" value="answer">'
                    + '</label></li>'
                + '</ul>' 
                + '<ul class="nobull">'
				    + '<li><label>'
					    + '<input type="radio">'
                        + '<input name="addanswer" type="text" value="answer">'
                    + '</label></li>'
                + '</ul>' 
            + '</div>'
            + '<div id="addcorrectAnswer' + counter + '" contenteditable="true">Correct Answer</div></br>';
    counter++;
    add.innerHTML += output;
}

function viewResults(questions, quizContainer, resultsContainer) {
	
	// gather answer containers from our quiz
	var answerContainers = quizContainer.querySelectorAll('.answers');
	
	// keep track of user's answers
	var userAnswer = '';
	var numCorrect = 0;
	
	// for each question...
	for(var i=0; i<questions.length; i++){

		// find selected answer
		userAnswer = (answerContainers[i].querySelector('input[name=question'+i+']:checked')||{}).value;
		
		// if answer is correct
		if(userAnswer===questions[i].correctAnswer){
			// add to the number of correct answers
			numCorrect++;
			
			// color the answers green
			answerContainers[i].style.color = 'lightgreen';
		}
		// if answer is wrong or blank
		else{
			// color the answers red
			answerContainers[i].style.color = 'red';
		}
	}

	// show number of correct answers out of total
	resultsContainer.innerHTML = numCorrect + ' out of ' + questions.length;
}

function saveQuiz() {

    fixedQuestions = []
    newQuestions = [];

    for(var i=0; i<myQuestions.length; i++)
    {
        var questionId = "question" + i;
        var answerClassName = "answer";
        var correctAnswerId = "correctAnswer" + i;

        var question = document.getElementsByClassName(questionId).textContent;
        var answersA = document.getElementsByName(answerClassName)[0].value;
        var answersB = document.getElementsByName(answerClassName)[1].value;
        var answersC = document.getElementsByName(answerClassName)[2].value;
        var answersD = document.getElementsByName(answerClassName)[3].value;
        var correctanswer = document.getElementsByClassName(correctAnswerId).textContent;

        fixedQuestions.push({question: question
            , answers: {
                a: answersA,
                b: answersB,
                c: answersC,
                d: answersD
            }
            , correctAnswer: correctanswer});

        myQuestions.push(fixedQuestions[i]);
    }

    for (var i = 0; i < counter; i++) {
        var questionId = "addquestion" + i;
        var answerClassName = "addanswer";
        var correctAnswerId = "addcorrectAnswer" + i;

        var question = document.getElementById(questionId).textContent;
        var answersA = document.getElementsByName(answerClassName)[0].value;
        var answersB = document.getElementsByName(answerClassName)[1].value;
        var answersC = document.getElementsByName(answerClassName)[2].value;
        var answersD = document.getElementsByName(answerClassName)[3].value;
        var correctanswer = document.getElementById(correctAnswerId).textContent;
    
        newQuestions.push({question: question
                            , answers: {
                                a: answersA,
                                b: answersB,
                                c: answersC,
                                d: answersD
                            }
                            , correctAnswer: correctanswer});

        myQuestions.push(newQuestions[i]);

        console.log(myQuestions);
    }

    //  This gives you a string in JSON syntax of the object above that you can 
    // send with XMLHttpRequest.
    var json = JSON.stringify(myQuestions);
    
    localStorage.setItem('v', json);
    console.log(json)
}