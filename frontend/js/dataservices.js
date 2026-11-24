//-----data-----
const base_url = "http://localhost:5063/api";

//-----elements-----

//-----functions-----
export const restaurantFetch = async () => {
    const response = await fetch(`${base_url}/restaurant`);

    if (!response.ok) {
        throw new Error(`Request failed: ${response.status}`);
    };

    const data = await response.json();
    return data;


};

export const navFetch = async () => {
    const response = await fetch(`${base_url}/category`);

    if (!response.ok) {
        throw new Error(`Request failed: ${response.status}`);
    };

    const data = await response.json();
    return data;

};

export const menuFetch = async () => {
    const response = await fetch(`${base_url}/menuitem`);

    if (!response.ok) {
        throw new Error(`Request failed. ${response.status}`);
    };

    const data = await response.json();
    return data;

};
//-----listeners-----

//-----run on load-----