import { render, screen, fireEvent } from "@testing-library/react";
import App from "../App";

test('renders Card Sorting App heading', () => {
  render(<App />);
  const headingElement = screen.getByText(/Sort My Deck/i);
  expect(headingElement).toBeInTheDocument();
});

test('allows user to input card values in the text field', () => {
  render(<App />);
  const inputElement = screen.getByRole('textbox', {name: /Enter cards/i });
  fireEvent.change(inputElement, { target : { value: '3C, JS, 2D'}});

  expect(inputElement.value).toBe('3C, JS, 2D');
});

test('disables the Sort Cards button when loading', () => {
  render(<App />);
  const buttonElement = screen.getByText(/Sort Cards/i);

  //Check if the button is enabled initially.
  expect(buttonElement).not.toBeDisabled();

  //Simulate a button click
  fireEvent.click(buttonElement);

  jest.mock('./api/cardService', () => ({
    sortCards: jest.fn(() => Promise.resolve(['3C', '2D', 'JS']))
  }))
  expect(buttonElement).toBeDisabled();
});

test("displays loader when sorting cards", async () => {
  render(<App />);
  const button = screen.getByText(/Sort Cards/i);
  fireEvent.click(button);

  expect(screen.getByText(/Sorting.../i)).toBeInTheDocument();
  await screen.findByText(/Sorted Cards/i);
});
