export const sortCards = async (cards) => {
    try{
        const response = await fetch("https://card-sorting-api-cygmfsf7ewh4g7ad.southeastasia-01.azurewebsites.net/api/cards/sort", {
            method: "POST",
            headers: {
            "Content-Type": "application/json",
            },
            body: JSON.stringify(cards),
        });
        if(!response.ok){
            const errorData = await response.json();
            throw new Error(errorData.message || "Failed to sort cards.");
        }
        const data = await response.json();
        return data;
    } catch (error) {
        throw new Error(error.message || "An unexpected error occurred.")
    }
};
