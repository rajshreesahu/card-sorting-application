import { useState } from "react";
import { sortCards } from "../api/cardService";

export const useSortCards = () => {
    const [sortedCards, setSortedCards] = useState([]);
    const [loading, setLoading] = useState(false);
    const [error, setError] = useState(null);

    const handleSortCards = async (cards) => {
        setLoading(true);
        setError(null);
        try {
            const sorted = await sortCards(cards);
            setSortedCards(sorted);
        } catch (err){
            setError('Failed to sort cards. Please try again.');
        }
        setLoading(false);
    };

    return { sortedCards, handleSortCards, loading, error };
};
