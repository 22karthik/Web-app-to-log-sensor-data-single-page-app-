<?php

include "connect.php";


$query="select NTC from log_lora";

$rs=$dbhandle->query($query);

while ($row = $rs->fetch_array()) {
  $data[] = $row['NTC'];
 
   
}

print json_encode($data);
	
	
?>
