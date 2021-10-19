pipeline {
    agent any
    
    environment {
            EMAIL_INFORM = 'bartlomiej.sapala@ibcs.pl'
    }
    
    stages {
        stage('Restore packages'){
           steps{
               bat 'dotnet restore Kartoteka-BartłomiejSapala\Kartoteka-BartłomiejSapala.csproj'
            }
         }
        stage('Clean'){
           steps{
               bat 'dotnet clean Kartoteka-BartłomiejSapala\Kartoteka-BartłomiejSapala.csproj --configuration Release'
            }
         }
        
        stage('Build project'){
            steps{
                bat 'dotnet build Kartoteka-BartłomiejSapala\Kartoteka-BartłomiejSapala.csproj'
            }
        }



    }
    post {  
         failure {  
             mail bcc: '', body: "<br>Project: ${env.JOB_NAME} <br>Build Number: ${env.BUILD_NUMBER} <br> URL build: ${env.BUILD_URL}", cc: '', charset: 'UTF-8', from: '', mimeType: 'text/html', replyTo: '', subject: "ERROR CI: Project name -> ${env.JOB_NAME}", to: "${EMAIL_INFORM}";  
         }  
 
     }  
}
