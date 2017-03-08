# Steps to reproduce stack overflow exception 

1. HTTP PUT To allocate memory up to the limit

  PUT /api/thing?id=78510c96-e0b8-45e5-95d9-3eab0b5e8215 HTTP/1.1
  Host: webapimemorylimit
  Acc: application/json
  Content-Type: application/json
  Cache-Control: no-cache

  99
  
2. POST to go over limit

  POST /api/thing HTTP/1.1
  Host: webapimemorylimit
  Content-Type: application/json
  Accept: application/json
  Cache-Control: no-cache

  {
    "Name": "Thing 1",
    "CreatedDateTime": "2017-03-01T00:54:43.8330231Z",
    "Description": "Long string here"
  }
  
App will crash 

2017-03-08T13:03:59.560-05:00 [APP/PROC/WEB/0] [ERR] **Process is terminated due to StackOverflowException.**
2017-03-08T13:04:00.051-05:00 [APP/PROC/WEB/0] [OUT] Exit status -1073741571
2017-03-08T13:04:00.447-05:00 [CELL/0] [OUT] Exit status -26
2017-03-08T13:04:00.466-05:00 [CELL/0] [OUT] Destroying container
2017-03-08T13:04:00.510-05:00 [API/0] [OUT] Process has crashed with type: "web"
2017-03-08T13:04:00.521-05:00 [API/0] [OUT] App instance exited with guid 7de96243-cc38-4021-a4b9-e2cca0a60d81 payload: 
  {"instance"=>"", "index"=>0, "reason"=>"CRASHED", "exit_description"=>"2 error(s) occurred:\n
  \n* Exited with status -1073741571\n* cancelled", "crash_count"=>1, "crash_timestamp"=>1488996240469248684,
  "version"=>"7cc05888-d03d-4c3b-a89e-eae28fdacab2"}
