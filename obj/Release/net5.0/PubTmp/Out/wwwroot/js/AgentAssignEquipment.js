const equipmentSelect = document.querySelector('#EquipmentType');
if (equipmentSelect != null) {


    equipmentSelect.addEventListener('change', async (e) => {

        const equipmentType = e.target.value.replace(/ /g, "_");


        fetch(`/Manager/GetBrandsByEquipmentType/${equipmentType}`, {
            method: "GET",
            credentials: "include"
        })
            .then(res => res.json())
            .then(res => {

                console.log(res);
                const brandSelect = document.querySelector('#BrandName');

                brandSelect.innerHTML = '<option disabled="" selected="">--Select Brand--</option>';

                res.map(op => {
                    let option = document.createElement('option');
                    option.value = op.brandName;
                    option.textContent = op.brandName;

                    brandSelect.appendChild(option);
                })
            })
    })
}