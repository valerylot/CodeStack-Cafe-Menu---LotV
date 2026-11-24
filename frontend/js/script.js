import { restaurantFetch, navFetch, menuFetch } from "./dataservices.js";
//-----data-----

//-----elements-----
//header
const restaurantInfo = document.getElementById("restaurant-info");
const restaurantName = document.getElementById("restaurant-name");
const tagline = document.getElementById("tagline");

//category nav
const categoryNav = document.getElementById("category-nav");

//menu
const menu = document.getElementById("menu");
const status = document.getElementById("status");

//footer
const footerName = document.getElementById("footer-name");
const footerInfo = document.getElementById("footer-info");

//-----functions-----
const loadRestaurant = async () => {
    try {
        const data = await restaurantFetch();
        showRestaurantInfo(data[0]);
        loadFooter(data[0]);

    } catch (error) {
        status.textContent = "Couldn't load restaurant information.";
        console.log(error);
    }
};

const loadMenu = async () => {
    try {
        const categories = await navFetch();

        categories.forEach((category) => {
            showNav(category);
        })

        const items = await menuFetch();

        items.forEach((item) => {
            showMenuItem(item);
        })

    } catch (error) {
        status.textContent = "Couldn't load menu information.";
        console.log(error);
    }
};

const showRestaurantInfo = (restaurant) => {

    const address = document.createElement("p");
    address.textContent = `${restaurant.address}`;
    address.classList.add("text-stone-500");

    const hours = document.createElement("p");
    hours.textContent = `${restaurant.hours}`;
    hours.classList.add("text-stone-500");


    const phone = document.createElement("p");
    phone.textContent = `${restaurant.phone}`;
    phone.classList.add("text-stone-500");

    restaurantName.textContent = restaurant.name;
    tagline.textContent = restaurant.tagline;


    restaurantInfo.appendChild(address);
    restaurantInfo.appendChild(hours);
    restaurantInfo.appendChild(phone);

}



const showNav = (category) => {
    const navItem = document.createElement("li");
    // navItem.textContent = category.name;
    navItem.classList.add("rounded-full", "border", "border-black", "p-2")

    const link = document.createElement("a");
    link.textContent = `${category.name}`;
    link.href = `#category-${category.id}`

    //section for the different categories
    const section = document.createElement("section");
    section.id = `category-${category.id}`
    section.classList.add("mb-10")

    const categoryHeader = document.createElement("section");
    categoryHeader.classList.add("flex", "justify-between", "items-center", "mx-4", "my-10")

    const categoryName = document.createElement("h2");
    categoryName.textContent = `${category.name}`;
    categoryName.classList.add("font-bold", "text-5xl", "md:text-6xl", "uppercase")


    //article for the menu items in each category
    const itemsContainer = document.createElement("article");
    itemsContainer.id = `category-${category.id}-items`;
    itemsContainer.classList.add("mx-4", "grid", "grid-cols-1", "md:grid-cols-2", "lg:grid-cols-3", "gap-6", "mb-5", "pb-6")


    const categoryId = document.createElement("p");
    categoryId.textContent = `${category.id.toString().padStart(2, "0")}`;
    categoryId.classList.add("text-orange-700", "font-serif", "italic", "text-3xl", "sm:text-5xl")



    navItem.appendChild(link);
    categoryNav.appendChild(navItem);

    categoryHeader.appendChild(categoryName);
    categoryHeader.appendChild(categoryId);

    section.appendChild(categoryHeader);
    section.appendChild(itemsContainer);
    // section.appendChild(categoryItems);
    menu.appendChild(section);
}


const showMenuItem = (item) => {

    const categoryItems = document.getElementById(`category-${item.category_Id}-items`);
    categoryItems.classList.add("gap-6", "mb-5", "border-b", "border-stone-500");

    const menuCard = document.createElement("article");
    menuCard.classList.add("flex", "flex-col", "gap-4")

    const itemNamePrice = document.createElement("section");
    itemNamePrice.classList.add("flex", "justify-between", "mt-2", "gap-2", "items-baseline");

    const dottedLine = document.createElement("div");
    dottedLine.classList.add("flex-1", "border-b", "border-dotted", "border-stone-400")

    const itemName = document.createElement("h3");
    itemName.textContent = `${item.name}`;
    itemName.classList.add("text-xl", "sm:text-2xl", "font-semibold")

    const price = document.createElement("p");
    price.textContent = `$${item.price.toFixed(2)}`;
    price.classList.add("text-orange-700", "font-semibold", "text-xl", "sm:text-2xl")

    const description = document.createElement("p");
    description.textContent = item.description;
    description.classList.add("text-stone-500")

    const tag = document.createElement("p");
    tag.textContent = item.tag;
    tag.classList.add("text-stone-600", "uppercase", "text-sm", "font-semibold", "bg-stone-200", "rounded-full", "px-2", "py-1", "w-fit", "mb-10")

    const img = document.createElement("img");
    img.src = `${item.image_Url}`;
    img.alt = `Image of ${item.name}`;
    img.classList.add("w-full", "h-30", "object-cover")

    const categoryId = document.createElement("p");
    categoryId.textContent = `${item.category_Id}`;

    status.textContent = "";

    menuCard.appendChild(img);
    itemNamePrice.appendChild(itemName);
    itemNamePrice.appendChild(dottedLine);
    itemNamePrice.appendChild(price);
    menuCard.appendChild(itemNamePrice);
    menuCard.appendChild(description);
    menuCard.appendChild(tag);

    categoryItems.appendChild(menuCard);

}

const loadFooter = (restaurant) => {
    footerName.textContent = restaurant.name;

    const address = document.createElement("p");
    address.textContent = `${restaurant.address}`;
    address.classList.add("text-stone-500");

    const hours = document.createElement("p");
    hours.textContent = `${restaurant.hours}`;
    hours.classList.add("text-stone-500");


    const phone = document.createElement("p");
    phone.textContent = `${restaurant.phone}`;
    phone.classList.add("text-stone-500");

    footerInfo.appendChild(address);
    footerInfo.appendChild(hours);
    footerInfo.appendChild(phone);

}





//-----listeners-----

//-----run on load-----
loadRestaurant();
loadMenu();
