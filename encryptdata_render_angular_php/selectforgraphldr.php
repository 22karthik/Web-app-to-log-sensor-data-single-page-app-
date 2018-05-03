<?php

include "connect.php";
//include "decrypt_data.php";



$query="select LDR1 from node2";

$rs=$dbhandle->query($query);

while ($row = $rs->fetch_array()) {
  $data[] = $row['LDR1'];
}

	
    
    print json_encode($data);
?>
