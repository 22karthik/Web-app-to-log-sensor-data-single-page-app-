<?php

include "connect.php";
//include "decrypt_data.php";



$query="select NTC1 from node2";

$rs=$dbhandle->query($query);

while ($row = $rs->fetch_array()) {
  $data[] = $row['NTC1'];
}

	
    
    print json_encode($data);
?>
