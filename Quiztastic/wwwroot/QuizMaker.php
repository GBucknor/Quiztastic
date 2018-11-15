<!DOCTYPE html>
<html>
    <head>
        <meta charset="UTF-8">
        <meta name="viewport" content="width=device-width, initial-scale=1">
        <title>Quiz Maker</title>

        <!-----Bootstrap----->
        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
        <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>

        <link rel="stylesheet" type="text/css" href="Style/QuizStyle.css">
        </head>

    <body>
        <div class="wrapper">
            <h1>Quiz Maker</h1>
        </div>
        <?php require 'DB.php';
            echo "yay";
        ?>
        <div class="wrapper">
                <div id="quiz"></div>
                <button id="save">Save</button>
                <button id="add">Add</button>
                <div id="results"></div>
        </div>

        <script src="Model/Model.js" type="text/javascript" ></script>
        <script src="View/View.js" type="text/javascript" ></script>
        <script src="Controller/Controller.js" type="text/javascript" ></script>
        <script src="Model/StudentModel.js" type="text/javascript" ></script>
        
    </body>
</html>
