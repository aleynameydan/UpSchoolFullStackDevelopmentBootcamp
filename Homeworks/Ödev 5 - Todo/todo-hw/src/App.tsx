import { useState } from 'react';
import { Container, Header, Form, Input, Button, Icon, List, Grid } from 'semantic-ui-react';
import 'semantic-ui-css/semantic.min.css';

function App() {
    const [todos, setTodos] = useState([]);
    const [idCounter, setIdCounter] = useState(1);
    const [newTodo, setNewTodo] = useState('');
    const [showNewest, setShowNewest] = useState(false);


    const handleInputChange = (e) => {
        setNewTodo(e.target.value);
    };

    const handleAddTodo = () => {
        if (newTodo.trim() !== '') {
            const todo = {
                id: idCounter,
                task: newTodo,
                isCompleted: false,
                createdDate: new Date(),
            };
            setTodos([...todos, todo].sort((a, b) => new Date(a.createdDate) - new Date(b.createdDate)));
            setNewTodo('');
            setIdCounter(idCounter + 1);
        }
    };

    
    const handleToggleComplete = (id) => {
        setTodos((prevTodos) =>
            prevTodos.map((todo) => {
                if (todo.id === id) {
                    return { ...todo, isCompleted: !todo.isCompleted };
                }
                return todo;
            })
        );
    };

    const handleRemoveTodo = (id) => {
        setTodos((prevTodos) => prevTodos.filter((todo) => todo.id !== id));
    };

    const handleShowNewest = () => {
        setShowNewest(!showNewest);
    };
    

    return (
        <Container className="center aligned">
            <Header as="h1" textAlign="center">
                Todos
            </Header>
            <Grid columns={2}>
                <Grid.Row verticalAlign="middle">
                    <Grid.Column width={14}>
                        <Form>
                            <Form.Field>
                                <Input
                                    fluid
                                    type="text"
                                    value={newTodo}
                                    placeholder="Add new task"
                                    onChange={handleInputChange}
                                />
                            </Form.Field>
                        </Form>
                    </Grid.Column>
                    <Grid.Column width={2}>
                        <Button
                            fluid
                            icon
                            labelPosition="left"
                            disabled={!newTodo.trim()}
                            onClick={handleAddTodo}
                        >
                            <Icon name="plus" />
                            Ekle
                        </Button>

                    </Grid.Column>
                </Grid.Row>
            </Grid>

            <Grid columns={3} stackable>
                <List divided relaxed>
                    {todos
                        .filter((todo) => !showNewest || new Date(todo.createdDate) >= new Date())
                        .sort((a, b) => new Date(b.createdDate) - new Date(a.createdDate))
                        .map((todo) => (
                        <List.Item
                            key={todo.id}
                            style={{ textDecoration: todo.isCompleted ? 'line-through' : '' }}
                            onDoubleClick={() => handleToggleComplete(todo.id)}
                        >
                            <List.Content floated="right">
                                <Icon
                                    name="trash alternate outline"
                                    color="red"
                                    onClick={() => handleRemoveTodo(todo.id)}
                                    style={{ cursor: 'pointer' }}
                                />
                            </List.Content>
                            <List.Content>
                                <List.Header>ID: {todo.id}</List.Header>
                                <p>Task: {todo.task}</p>
                                <p>Completed: {todo.isCompleted ? 'Yes' : 'No'}</p>
                                <p>Created Date: {todo.createdDate.toLocaleString()}</p>
                            </List.Content>
                        </List.Item>
                    ))}
                </List>
                
            </Grid>
           
        </Container>
    );
}

export default App;
