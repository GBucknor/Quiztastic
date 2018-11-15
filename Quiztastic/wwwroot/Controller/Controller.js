function generateQuiz(questions, quizContainer, resultsContainer, submitButton){

	// show the questions
	viewQuestions(questions, quizContainer);

	// when user clicks submit, show results
	saveButton.onclick = function(){
        saveQuiz();    
    }
}
generateQuiz(myQuestions, quizContainer, resultsContainer, submitButton);
