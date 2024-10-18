import React, {useState} from "react";
import { Container, Button, TextField, Card, CardContent, Typography, createTheme, ThemeProvider } from '@mui/material';
import CardList from './components/CardList';
import { useSortCards } from "./hooks/useSortCards";
import '@fontsource/playfair-display';

const theme = createTheme({
  palette: {
    primary: {
      main: '#D32F2F',
    },
    text: {
      primary: '#000000',
    }
  }
})
const App = () => {
  const [inputCards, setInputCards] = useState(''); //user input
  const [cards, setCards] = useState([]); //store parsed cards from user input
  const { sortedCards, handleSortCards, loading, error } = useSortCards();

  //handle user input submission
  const handleSubmit = (e) => {
    e.preventDefault();
    const parsedCards = inputCards.split(',').map(card => card.trim()); //Parse input into an array
    setCards(parsedCards);
    handleSortCards(parsedCards);
  };

  return (
    <ThemeProvider theme={theme}>
      <Container maxWidth="sm" style={{ marginTop: '50px' }}>
        <Card elevation={3}>
          <CardContent>
            <Typography
              variant="h3"
              component="h1"
              align="center"
              gutterBottom
              sx={{
                fontFamily: '"Playfair Display", serif',
                fontWeight: 700,
                color: '#F5F5F5',
                textShadow: '2px 2px 4px rgba(0, 0, 0, 1.0)',
                marginBottom: '20px',
              }}
            >
              Sort My Deck
            </Typography>

          {/* Form to input cards */}
          <form onSubmit={handleSubmit} style={{ display: 'flex', justifyContent: 'center', marginBottom: '20px' }}>
            <TextField
              label="Enter cards (e.g., 3C, JS, 2D)"
              variant="outlined"
              value={inputCards}
              onChange={(e) => setInputCards(e.target.value)}
              sx={{
                width: '300px',
              }}
            />
            <Button 
              type="submit"
              variant="contained"
              sx={{
                margin: '0px 10px',
                backgroundColor: '#D32F2F',
                color: '#fff',
                '&:hover': {
                  backgroundColor: '#C62828',
                },
              }}
              disabled={loading}
            >
              {loading ? 'Sorting...' : 'Sort Cards'}
            </Button>
          </form>

          {/* Loader while sorting */}
          {loading && <div className="loader"></div>}

          {/* Display any errors */}
          {error && <Typography color="error" fontWeight={'bold'} align="center">{error}</Typography>}

          {/* Display sorted cards once sorted */}
          {sortedCards.length > 0 && <CardList cards={sortedCards} title="Sorted Cards" />}
          </CardContent>
        </Card>
      </Container>
    </ThemeProvider>
  );
};

export default App;