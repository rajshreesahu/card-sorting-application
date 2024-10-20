import React from "react";
import Card from "./Card";
import { useTrail, animated } from 'react-spring';
import '../styles/styles.css'

const CardList = ({ cards, title }) => {
    const trail = useTrail(cards.length, {
        from: { opacity: 0, transform: "translateY(-30px)" },
        to: { opacity: 1, transform: "translateY(0px)" },
        config: { tension: 250, friction: 25 },
    });
    return (
        <div className="container">
            <h3 className="h3">{title}</h3>
            <div className="cards-container">
                {trail.map((style, index) => (
                    <animated.div key={index} style={style}>
                        <Card card={cards[index]}/>
                    </animated.div>
                ))}
            </div>
        </div>
    );
};

export default CardList;
