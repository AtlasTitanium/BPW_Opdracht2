using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGetable {
	void OnGet(GameObject pickupPlace);

	void OnDrop(GameObject pickupPlace);

}
