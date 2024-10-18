import React from "react";
import '../styles/styles.css'

const Card = ({ card }) => {
    try {
        const cardImage = require(`../assets/cards/${card}.png`);
        return (
            <div className="card">
                <img src={cardImage} alt={card} className="card-image" />
            </div>
        )
    } catch (error){
        return <div className="card">Image not found</div>
    }
};

export default Card;
