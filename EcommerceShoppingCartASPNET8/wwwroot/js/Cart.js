document.querySelectorAll('.add-to-cart').forEach(button => {
    button.addEventListener('click', async (event) => {
        const productId = event.target.dataset.productId;
        const quantityInput = document.getElementById(`quantity-${productId}`);
        const quantity = quantityInput.value;

        const response = await fetch(`/Cart/AddToCart`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ productId, quantity })
        });

        if (response.ok) {
            const cart = await response.json();
            if (cart.updated) {
                alert('Product quantity updated in cart');
            } else {
                alert('Product added to cart');
            }
        } else {
            alert('Failed to add product to cart');
        }
    });
});

document.addEventListener("DOMContentLoaded", () => {
    // Select all Remove buttons
    const removeButtons = document.querySelectorAll(".remove-from-cart");

    // Add click event listener to each Remove button
    removeButtons.forEach((button) => {
        button.addEventListener("click", async (event) => {
            event.preventDefault(); // Prevent any default behavior like form submission

            // Get the product ID from the closest parent element (or button itself)
            const productId = event.target.closest("tr").dataset.productId;

            if (!productId) {
                alert("Failed to identify the product to remove.");
                return;
            }

            // Send the request to the backend to remove the product from the cart
            try {
                const response = await fetch(`/cart/remove?productId=${productId}`, {
                    method: "POST"
                });

                if (response.ok) {
                    alert("Product removed from the cart successfully.");

                    // Optionally, remove the product's row from the DOM
                    const productRow = event.target.closest("tr"); // Assumes products are in table rows
                    if (productRow) {
                        productRow.remove();
                    }
                } else {
                    alert("Failed to remove product from cart. Please try again.");
                }
            } catch {
                alert("An error occurred. Please check your internet connection or try again later.");
            }
        });
    });
});

// Function to update the product quantity in the view
function updateQuantityInProductView(productId, quantity) {
    const quantityElement = document.getElementById(`quantity-${productId}`);
    quantityElement.value = quantity;
}
