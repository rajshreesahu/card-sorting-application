export const sortCards = async (cards) => {
    const response = await fetch("/api/sort", {
        method: "POST",
        headers: {
        "Content-Type": "application/json",
        },
        body: JSON.stringify(cards),
    });
    if(!response.ok){
        throw new Error('Failed to sort cards');
    }
    const data = await response.json();
    return data.sortedCards;
};
