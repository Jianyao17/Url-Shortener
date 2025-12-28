export type AxisScale = 'value' | 'log' | 'time' | 'category'

export interface AxisTickConfig 
{
  min?: number
  max?: number
  interval?: number
  formatter?: (value: number) => string
}
