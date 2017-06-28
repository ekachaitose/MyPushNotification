<?PHP
	function sendMessage(){
		$headings = array(
			"en" => 'CodeMobiles'
			);
		$content = array(
			"en" => 'I Love CodeMobiles from Rest API'
			);

		// https://documentation.onesignal.com/reference#create-notification
		$fields = array(
			'app_id' => "6021c18b-18dc-4885-8fe2-8f237176a92e", // onsignal app id
			'included_segments' => array('All'),
			//'include_player_ids' => array("ebbab069-5682-48ba-b5d4-7d11ec59c449", "6b6f0672-b21e-4ef1-bdd9-fac2961475dd"),
			//'filters' => array(array("field" => "tag", "key" => "level", "relation" => "=", "value" => "10"),array("operator" => "OR"),array("field" => "amount_spent", "relation" => "=", "value" => "0")),
			//'big_picture' => 'http://www.codemobiles.com/biz/images/cm_logo.png?ref=10',
			'small_icon' => 'ic_stat_ic_notification',
			//'android_sound' => 'sound',
			'data' => array("foo" => "bar"),
			'headings' => $headings,
			'contents' => $content
		);

		$fields = json_encode($fields);
	    print("\nJSON sent:\n");
	    print($fields);

		$ch = curl_init();
		curl_setopt($ch, CURLOPT_URL, "https://onesignal.com/api/v1/notifications");
		curl_setopt($ch, CURLOPT_HTTPHEADER, array('Content-Type: application/json; charset=utf-8',
												   'Authorization: Basic MTkxYzIyNjktNjBlZS00MWU1LWI1ZWQtYzY3NjUzZTAwMjc0')); // Rest API Key
		curl_setopt($ch, CURLOPT_RETURNTRANSFER, TRUE);
		curl_setopt($ch, CURLOPT_HEADER, FALSE);
		curl_setopt($ch, CURLOPT_POST, TRUE);
		curl_setopt($ch, CURLOPT_POSTFIELDS, $fields);
		curl_setopt($ch, CURLOPT_SSL_VERIFYPEER, FALSE);

		$response = curl_exec($ch);
		curl_close($ch);
		
		return $response;
	}
	
	$response = sendMessage();
	$return["allresponses"] = $response;
	$return = json_encode( $return);
	
  	print("<br><br>JSON received:<br>");
	print($return);
  	print("<br>");
?>