<?php
    class DB
    {
        private $servername = "127.0.0.1";
        private $username = "root";
        private $password = "";
        private $dbname = "db3333";

        public function connect()
        {
            $this->conn = new mysqli(
                $this->servername, 
                $this->username,
                $this->password,
                $this->dbname
            );
            return;
        }

        public function Insert($Question, $Answer1, $Answer2, $Answer3, $Answer4, $CorrectAnswer)
        {
            $sql = "INSERT INTO questions (Question, AnswerOne, AnswerTwo, AnswerThree, AnswerFour, CorrectAnswer) 
                        VALUES (\"$Question\",\"$Answer1\", \"$Answer2\", \"$Answer3\", $Answer4\", \" $CorrectAnswer)";
            $result = $this->conn->query($sql);
            if ($result == true)
            {
                echo "Records added! </br>";
            }            
        }

        public function ListQuestions()
        {
            $sql = "SELECT * FROM questions";
            $result = $this->conss->query($sql);

            if($result->num_rows > 0)
            {
                while($row = $result->fetch_assoc())
                {
                    echo "Question: " .$row["Question"]."<br>";
                }
            } else {
                echo "0 results";
            }
        }

        public function disconnect()
        {
            $this->conn->close();
        }
    }

    $obj = new DB();
    $obj->connect();
    $obj->insert("What is 3+4?", "6", "7", "8", "9", "b");
    $obj->ListQuestions();
?>