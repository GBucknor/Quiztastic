var quizContainerStudent;
var resultsContainer;
var submitButton;

var myquestions = [];

if (localStorage.getItem('v') === null) {
    confirm("There was no quiz for you!");
} else {
    myquestions = JSON.parse(localStorage.getItem('v'));
    console.log(myquestions)
}



